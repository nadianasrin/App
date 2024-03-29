﻿$(document).ready(function() {
    FetchSemesters();
    $("#semesterForm").submit(function(e) {
        e.preventDefault();
        var semesterName = $("#SemesterName option:selected").text();
        console.log(semesterName);
        $.post('/Officer/CreateSemester',{sName: semesterName}, function (response) {
            if(response === "success")
            {
                showToast("Semester created successfully", "green darken-1");
                FetchSemesters();
            }
            else if(response === "invalidSemester")
            {
                showToast("Please select a semester", "amber darken-4");
            }
            else if (response === "fail")
            {
                showToast("Something went wrong", "red darken-1");
            }
            else if(response === "semesterExists")
            {
                showToast("Semester already exists", "red darken-1");
            }
            else
            {}
        })
    });
});


function FetchSemesters() {
    
    var semesters = $("#semesterCards");
    $.get('/Officer/FetchSemesters', function (response) {
        console.log(response.length);
        var messsage = " <div class=\"center-align\">\n" +
            "                <h4 class=\"purple-text text-darken-4\">Semesters</h4>\n" +
            "            </div>";
       for(var i = response.length - 1 ; i >= 0; i--)
       {
           var semesterCard = "<div class=\"col s6 m3\">\n" +
               "                <div class=\"card z-depth-2 card-border hoverable\">\n" +
               "                    <div class=\"card-image waves-effect waves-block waves-light\">\n" +
               "                        <a href=\"batch22.html\"><img class=\"cimage\" src=\"https://cadetkid.github.io/UI/assets/img/summer.png\"></a>\n" +
               "                    </div>\n" +
               "                    <div class=\"card-content\">\n" +
               "                        <span class=\"card-title clink\"><a target=\"_blank\" href=\"/Officer/"+response[i]["semesterId"]+"\">"+response[i]["semesterName"]+"</a><a href=\"#\"><i class=\"material-icons right\">delete</i></a></span>\n" +
               "                    </div>\n" +
               "                </div>\n" +
               "            </div>"
           messsage += semesterCard;
       }
        semesters.html(messsage);
       
    })
}

function showToast(message, style) {
    M.toast({
        html : message,
        classes : style
    });
}