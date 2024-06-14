/// <reference path="../scripts/globals.d.ts" />
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
/////////////////////////
const fields = document.querySelectorAll(".kanbanField"); //поля доски канбан
let stick; //задача
let sticks; //коллекция задач
function AssignName(id) {
    //добавляем имя проекта на титул доски
    const allProj = document.getElementsByClassName("projectName");
    let currentProject = "";
    for (let i = 0; i < allProj.length; i++) {
        if (i == id) {
            currentProject = allProj[i].textContent;
            document.getElementById("nameProject").textContent = currentProject;
            break;
        }
    }
    //добавляем в правое поле список участников проекта
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
    //добавляем задачи на доску канбан
    sticks = [];
    let counterSticks = 0;
    $('.sticks').remove();
    for (let i = 0; i < allData.length; i++) {
        if (allData[i].Project == currentProject) {
            if (allData[i].TaskStatus == "todo") {
                addStick(i, counterSticks, ".todo");
            }
            else if (allData[i].TaskStatus == "doing") {
                addStick(i, counterSticks, ".doing");
            }
            else if (allData[i].TaskStatus == "done") {
                addStick(i, counterSticks, ".done");
            }
            counterSticks++;
        }
    }
}
function catchStick(ind) {
    stick = undefined;
    stick = sticks[ind];
    fields.forEach((field) => {
        field.addEventListener("dragover", (e) => {
            e.preventDefault();
        });
        field.addEventListener("drop", () => {
            field.append(stick);
            const deg = Math.round(Math.random() * 10) - 5;
            $(stick).css('transform', 'rotate(' + deg + 'deg)');
        });
    });
}
function addStick(i, counterSticks, nameField) {
    stick = undefined;
    $(nameField).append('<div class="sticks" id="stick' + counterSticks + '"  draggable="true" onmousedown="catchStick(' + counterSticks + ')" >' +
        '<div class="task">' +
        '<span>' + allData[i].TaskName + '</span>' +
        '</div>' +
        '<div class="executor">' +
        '<span>' + allData[i].UserLName + " " + allData[i].UserFName[0] + "." + allData[i].UserSName[0] + '</span>' +
        '</div>' +
        '</div>');
    stick = document.querySelector('#stick' + counterSticks);
    sticks.push(stick);
    const deg = Math.round(Math.random() * 10) - 5;
    $(sticks[counterSticks]).css('transform', 'rotate(' + deg + 'deg)');
}
//# sourceMappingURL=project.js.map