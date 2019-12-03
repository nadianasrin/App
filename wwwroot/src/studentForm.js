$(document).ready(function () {
    var courses = $('#viewCourseCodeField');
    courses.hide();
    $("#cc").change(function () {
        var semesterName = $("#cc option:selected").text();
        $.getJSON('/Student/GetCourseOfSemester', {semester: semesterName}, function (response) {
            console.log(response);
            var courseField = "";
            $.each(response, function (key, value) {
                if (value == null) {
                    $("#viewCourseCodeField").empty();
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
        var batch = $("#Batch option:selected").text();
        var semesterNumber = $("#cc option:selected").text();
        var course01 = $("#c01").val();
        var course02 = $("#c02").val();
        var course03 = $("#c03").val();
        var course04 = $("#c04").val();
        var course05 = $("#c05").val();
        var section = $("#section option:selected").text();
        
        console.log(studentId);
        console.log(batch);
        console.log(semesterNumber);
        console.log(course01);
        console.log(Section);

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
            
        }
        
    })
    
});