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
            else if(response === "validsemester")
            {
                showToast("Please select a semester", "amber darken-1");
            }
            else if (response === "fail")
            {
                showToast("Something went wrong", "red darken-1");
            }
        })
    });
});


function FetchSemesters() {
    
    var semesters = $("#semesterCards");
    $.get('/Officer/FetchSemesters', function (response) {
        console.log(response.length);
        var messsage = "";
       for(var i = response.length - 1 ; i >= 0; i--)
       {
           var semesterCard = "<div class=\"col s6 m3\">\n" +
               "                <div class=\"card z-depth-2\">\n" +
               "                    <div class=\"card-image waves-effect waves-block waves-light\">\n" +
               "                        <a href=\"batch22.html\"><img class=\"cimage\" src=\"https://cadetkid.github.io/UI/assets/img/summer.png\"></a>\n" +
               "                    </div>\n" +
               "                    <div class=\"card-content\">\n" +
               "                        <a target='_blank' class=\"btn-floating activator btn-move-up waves-effect waves-light z-depth-4 right\" href=\"/Officer/"+temptid+"/"+response[i]["classroomId"]+"\">" +
               "                            <i class=\"material-icons\">send</i>\n" +
               "                        </a>\n" +
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