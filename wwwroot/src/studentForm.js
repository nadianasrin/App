$(document).ready(function () {
    var courses = $('#viewCourseCodeField');
    courses.hide();
    $("#SemesterList").change(function () {
        $("#c01").val('');
        $("#c02").val('');
        $("#c03").val('');
        $("#c04").val('');
        $("#c05").val('');
        var semesterName = $("#SemesterList option:selected").text();
        $.getJSON('/Student/GetCourseOfSemester', {semester: semesterName}, function (response) {
            $.each(response, function (key, value) {
                if (value == null) {
                    courses.empty();
                }
                else {
                    for(var i = 0; i < response.length; i++)
                    {
                        var inputField = "c0".concat((i+1).toString());
                        $('#'+inputField).val(response[i]["courseCode"]);
                    }
                    courses.show();
                }
            });
        })
    });
    
    // form submission 
    $('#studentForm').submit(function (e) {
        e.preventDefault();
        var studentId = $("#Registration_StudentVarsityId").val();
        var semesterName = $("#Semester_Name").val();
        var batch = $("#Batch option:selected").text();
        var semesterNumber = $("#cc option:selected").text();
        var course01 = $("#c01").val();
        var course02 = $("#c02").val();
        var course03 = $("#c03").val();
        var course04 = $("#c04").val();
        var course05 = $("#c05").val();
        var section = $("#Section option:selected").text();
        var studentForm = {
            "studentId": studentId,
            "batch": batch,
            "semesterNumber": semesterNumber,
            "course01": course01,
            "course02": course02,
            "course03": course03,
            "course04": course04,
            "course05": course05,
            "section": section
        };

        $.post('/Student/SaveStudentInfo',{studentForm: studentForm}, function (response) {
            console.log(response);
            if(response === "enrolled")
            {
                showToast("You already have enrolled", "amber darken-2");
            }
            else if(response === "success")
            {
                showToast("Successfully enrolled", "green darken-1");
            }
            else if(response === "failed")
            {
                showToast("Something went wrong!", "red darken-1");
            }
        })
    })
});

function showToast(message, style) {
    M.toast({
        html : message,
        classes : style
    });
}