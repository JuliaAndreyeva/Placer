/// <binding />
"use strict";

import gulp from "gulp";
import cssmin from "gulp-cssmin";
import jsmin from "gulp-terser";
import bundleconfig from "./bundleconfig.json" assert { type: "json" };
import imagemin from 'gulp-imagemin';
import dartSass from 'sass'
import gulpSass from 'gulp-sass'
import rename from 'gulp-rename'
import gulpIf from 'gulp-if'

const sass = gulpSass(dartSass)

const pathsSrc = {
    webroot: "wwwroot/"
}

const pathsDest = {
    js:  "wwwroot/dist/js",
    css: "wwwroot/dist/css",
    img: "wwwroot/dist/images"
}

pathsSrc.js = pathsSrc.webroot + "js/**/*.js";
pathsSrc.css = pathsSrc.webroot + "css/**/*.css";
pathsSrc.scss = pathsSrc.webroot + "scss/**/*.scss";
pathsSrc.images = pathsSrc.webroot + "images/*";

gulp.task('sass-to-css', function () {
    return gulp.src(pathsSrc.scss)
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('./wwwroot/css'))
});
gulp.task('min-js', function () {
    return gulp.src(pathsSrc.js)
        .pipe(gulpIf(file => !/(^|\\|\/)min\.js$/.test(file.relative), jsmin()))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest(pathsDest.js));
});
gulp.task('min-css', function () {
    return gulp.src(pathsSrc.css)
        .pipe(gulpIf(file => !/(^|\\|\/)min\.css$/.test(file.relative), cssmin()))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest(pathsDest.css));
});
gulp.task('watch', function () {
    gulp.watch(paths.scss, gulp.series(['sass-to-css']));
    gulp.watch(paths.js, gulp.series(['min-js']));
    gulp.watch(paths.css, gulp.series(['min-css']));
    gulp.watch(paths.images, gulp.series(['min-image']));
});
gulp.task('min-image', function () {
    return gulp.src(pathsSrc.images)
        .pipe(imagemin())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest(pathsDest.img));
});
gulp.task('browser-sync', function () {
    browserSync.init({
        server: {
            baseDir: "wwwroot/"
        }
    });
});

gulp.task('min', gulp.series('sass-to-css', 'min-image', 'min-css', 'min-js'));

gulp.task('default', gulp.series('sass-to-css', 'min-image','min-css','min-js','watch'));