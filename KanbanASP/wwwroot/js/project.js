/// <reference path="../scripts/globals.d.ts" />
//import Global from ""
let animatedLeft = false;
let animatedRight = false;
function leftBtnClick() {
    if (!animatedLeft) {
        $(".left").css('flex', '0 0 15%');
        $(".leftbtn").css('transform', 'rotate(180deg)');
        setTimeout(() => $(".contentLeft").css("display", "flex"), 500);
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
        setTimeout(() => $(".contentRight").css("display", "flex"), 500);
        animatedRight = true;
    }
    else if (animatedRight) {
        $(".contentRight").css("display", "none");
        $(".rightbtn").css('transform', 'rotate(360deg)');
        $(".right").css('flex', '0 0 2%');
        animatedRight = false;
    }
}
let isVisibleAddProj = false;
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
        const str = document.getElementsByTagName("input")[0].value;
        $("#addNewProj").remove();
        $("#projects").append('<div class="project"><span onclick="method()" >' + str + '</span></div>');
        isVisibleAddProj = false;
    }
}
const fields = document.querySelectorAll(".kanbanField");
const sticks = document.querySelectorAll(".sticks");
let stick = null;
function catchStick(ind) {
    stick = sticks[ind];
}
fields.forEach((field) => {
    field.addEventListener("dragover", (e) => {
        e.preventDefault();
    });
    field.addEventListener("drop", () => {
        field.appendChild(stick);
        const deg = Math.round(Math.random() * 10) - 5;
        $(stick).css('transform', 'rotate(' + deg + 'deg)');
    });
});
/////////////////////////
function AssignName(id) {
    const allProj = document.getElementsByClassName("projectName");
    let currentProject = "";
    for (let i = 0; i < allProj.length; i++) {
        if (i == id) {
            currentProject = allProj[i].textContent;
            document.getElementById("nameProject").textContent = currentProject;
            break;
        }
    }
    let people = [];
    $(".contentRight").remove();
    $(".right").append('<div class="contentRight"></div>');
    for (let i = 0; i < allData.length; i++) {
        if (allData[i].Project == currentProject && !people.includes(allData[i].UserLName + " " + allData[i].UserFName + " " + allData[i].UserSName)) {
            $(".contentRight").append('<span>' + allData[i].UserLName + " " + allData[i].UserFName[0] + ". " + allData[i].UserSName[0] + '.</span>');
            people.push(allData[i].UserLName + " " + allData[i].UserFName + " " + allData[i].UserSName);
        }
    }
    if (animatedRight) {
        $(".contentRight").css("display", "flex");
    }
    var a;
}
//# sourceMappingURL=project.js.map