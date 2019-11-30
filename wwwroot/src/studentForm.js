$(document).ready(function () {
    $("#cc").change(function () {
        var courses = $("#viewCourseCodeField");
        var semesterName = $("#cc option:selected").text();
        $.getJSON('/Student/GetCourseOfSemester', {semester: semesterName}, function (response) {
            console.log(response);
            var courseField = "";
            $.each(response, function (i, value) {
                if (value == null) {
                    $("#viewCourseCodeField").empty();
                } else {
                    courseField += "<div class=\"input-field col s12 l12\">\n" +
                        "                        <input id=\"" + response[i].courseId + "\" type=\"text\" value=\"" + response[i].courseCode+"  ("+response[i].courseTitle+")" + "\">\n" +
                        "                        <label class=\"active\" for=\"course\">Course Code</label>\n" +
                        "                    </div>";
                }
            });
            courses.html(courseField);
        })
    });
});