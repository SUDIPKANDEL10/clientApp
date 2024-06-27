$(document).ready(function () {
    $("form").validate({
        rules: {
            Name: "required",
            Gender: "required",
            Phone: {
                required: true,
                phoneUS: true
            },
            Email: {
                required: true,
                email: true
            },
            Address: "required",
            Nationality: "required",
            DateOfBirth: {
                required: true,
                date: true
            },
            EducationBackground: "required",
            PreferredContact: "required"
        },
        messages: {
            Name: "Please enter your name",
            Gender: "Please select your gender",
            Phone: "Please enter a valid phone number",
            Email: "Please enter a valid email address",
            Address: "Please enter your address",
            Nationality: "Please enter your nationality",
            DateOfBirth: "Please enter your date of birth",
            EducationBackground: "Please enter your education background",
            PreferredContact: "Please select a preferred contact mode"
        }
    });
});
