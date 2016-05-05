/// <binding BeforeBuild='default' Clean='clean' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require("gulp"),
    concat = require("gulp-concat"),
    uglifyCss = require("gulp-uglifycss"),
    del = require("del");
gulp.task("clean",
    function() {
        return del(["Content/lib"]);
    });

gulp.task("copyJavaScript",
    function() {

        gulp.src([
                "bower_components/jquery/dist/jquery.min.js",
                "bower_components/bootstrap/dist/js/bootstrap.min.js"
            ])
            .pipe(concat("third-party.js"))
            .pipe(gulp.dest("Content/lib"));
    });

gulp.task("copyCss",
    function() {

        gulp.src(["bower_components/bootstrap/dist/css/bootstrap.min.css", "Content/signifly.css"])
            .pipe(uglifyCss())
            .pipe(concat("site.css"))
            .pipe(gulp.dest("Content/lib"));
    });

gulp.task("default", ["clean", "copyJavaScript", "copyCss"]);