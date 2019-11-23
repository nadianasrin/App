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
        var semesterName = $('#semester option:selected');
        
        console.log(formActiveStatus, semesterName);
    })
});