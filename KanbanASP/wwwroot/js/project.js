///// <reference path="global.d.ts" />
var animatedLeft = false;
var animatedRight = false;
function leftBtnClick() {
    if (!animatedLeft) {
        $(".left").css('flex', '0 0 15%');
        $(".leftbtn").css('transform', 'rotate(180deg)');
        setTimeout(function () { return $(".contentLeft").css("display", "flex"); }, 500);
        animatedLeft = true;
    }
    else if (animatedLeft) {
        $(".contentLeft").css("display", "none");
        $(".leftbtn").css('transform', 'rotate(360deg)');
        $(".left").css('flex', '0 0 2%');
        animatedLeft = false;
    }
}
function rightBtnClick() {
    if (!animatedRight) {
        $(".right").css('flex', '0 0 15%');
        $(".rightbtn").css('transform', 'rotate(180deg)');
        setTimeout(function () { return $(".contentRight").css("display", "flex"); }, 500);
        animatedRight = true;
    }
    else if (animatedRight) {
        $(".contentRight").css("display", "none");
        $(".rightbtn").css('transform', 'rotate(360deg)');
        $(".right").css('flex', '0 0 2%');
        animatedRight = false;
    }
}
var isVisibleAddProj = false;
function addNewProj() {
    if (!isVisibleAddProj) {
        $("#projects").append('<div id="addNewProj"></div>');
        $("#addNewProj").append('<input type="text" />');
        $("#addNewProj").append('<input type="button" value="OK" onclick="confirmProj()"/>');
        isVisibleAddProj = true;
    }
}
function confirmProj() {
    if (isVisibleAddProj) {
        var str = document.getElementsByTagName("input")[0].value;
        $("#addNewProj").remove();
        $("#projects").append('<div class="project"><span onclick="method()" >' + str + '</span></div>');
        isVisibleAddProj = false;
    }
}
var fields = document.querySelectorAll(".kanbanField");
var sticks = document.querySelectorAll(".sticks");
var stick = null;
function catchStick(ind) {
    stick = sticks[ind];
}
fields.forEach(function (field) {
    field.addEventListener("dragover", function (e) {
        e.preventDefault();
    });
    field.addEventListener("drop", function () {
        field.appendChild(stick);
        var deg = Math.round(Math.random() * 10) - 5;
        $(stick).css('transform', 'rotate(' + deg + 'deg)');
    });
});
/////////////////////////
//interface Window {
//    allData: any;
//}
//import { Global } from "./global";
function AssignName(id) {
    var allProj = document.getElementsByClassName("projectName");
    for (var i = 0; i < allProj.length; i++) {
        if (i == id) {
            document.getElementById("nameProject").textContent = allProj[i].textContent;
            break;
        }
    }
    //var a = allDada;
}
//# sourceMappingURL=project.js.map