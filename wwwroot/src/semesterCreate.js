$(document).ready(function (){
    
    $('#semesterForm').submit(function (e) {
        e.preventDefault();
        var formActiveStatus;
        $('#isActiveForm').change(function () {
            if($(this).prop("checked") === true){
                formActiveStatus = "Active";
            }
            else
            {
                formActiveStatus = "Inactive";
            }
        });
        var semesterName = $('#SemesterName option:selected').text();
        
        console.log(formActiveStatus, semesterName);
    })
});