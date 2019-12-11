$(document).ready(function() {
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
    
    $(".semesterCard")
});


function FetchSemesters() {
    
    var semesters = $("#semesterCards");
    $.get('/Officer/FetchSemesters', function (response) {
        console.log(response);
        console.log(response.length);
        
        var messsage = " <div class=\"center-align\">\n" +
            "                <h4 class=\"purple-text text-darken-4\">Semesters</h4>\n" +
            "            </div>";
       for(var i = response.length - 1 ; i >= 0; i--)
       {
           var semesterCard = "<div class=\"col s6 m3\">\n" +
               "                <div class=\"card z-depth-2 card-border\">\n" +
               "                    <div class=\"card-image waves-effect waves-block waves-light\">\n" +
               "                        <a href=\"batch22.html\"><img class=\"cimage\" src=\"https://cadetkid.github.io/UI/assets/img/spring.png\"></a>\n" +
               "                    </div>\n" +
               "                    <div class=\"card-content\">\n" +
               "                        <span class=\"card-title\"><a class=\"clink semesterCard\" id=\""+response[i]["semesterId"]+"\" href=\""+response[i]["semesterId"]+"\">"+response[i]["semesterName"]+"</a><a class=\"dropdown-trigger right\" data-target=\"dropdown\" href=\"#\"><i class=\"material-icons\">more_vert</i></a></span>\n" +
               "                    </div>\n" +
               "\n" +
               "                    <ul id=\"dropdown\" class=\"dropdown-content\">\n" +
               "                        <li> <a class=\"waves-effect waves-light modal-trigger\" href=\"#modal\">Modal</a></li>\n" +
               "                        <li><a href=\"#\">Active</a></li>\n" +
               "                    </ul>\n" +
               "\n" +
               "                    <div id=\"modal\" class=\"modal\">\n" +
               "                        <div class=\"modal-content\">\n" +
               "                            <div class=\"center-align\">\n" +
               "                                    <h5></h5>\n" +
               "                            </div>\n" +
               "                        </div>\n" +
               "                        <div class=\"modal-footer\">\n" +
               "                            <a class=\"modal-close waves-effect btn-small green \">Yes, Delete</a>\n" +
               "                            <a class=\"modal-close waves-effect btn-small red\">No</a>\n" +
               "                        </div>\n" +
               "                    </div>\n" +
               "                </div>\n" +
               "            </div>";
           
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