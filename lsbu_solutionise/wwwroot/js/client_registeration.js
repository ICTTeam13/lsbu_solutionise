$(document).ready(function () {
    // Function to show a specific step
    function showStep(step) {
        $(".step").hide(); // Hide all steps
        $(`#step${step}`).show(); // Show the specified step
    }

    // Function to validate fields in the current step
    function validateFields(step) {
        let isValid = true;

        // Loop through required fields in the current step
        $(`#step${step} input[required]`).each(function () {
            if (!$(this).val().trim()) {
                // Get the field name from asp-for or placeholder
                const fieldName = $(this).attr("asp-for") || $(this).attr("placeholder") || "This field";

                // Show validation error
                $(this).siblings(".text-danger").text(`${fieldName} is required.`).show();
                isValid = false;
            } else {
                // Hide validation error if valid
                $(this).siblings(".text-danger").text("").hide();
            }
        });

        return isValid;
    }

    // Next button click
    $(".next").click(function () {
        const currentStep = $(this).closest(".step").attr("id").replace("step", ""); // Get current step number

        if (validateFields(currentStep)) {
            const nextStep = parseInt(currentStep) + 1; // Calculate next step
            showStep(nextStep); // Show the next step
        }
    });

    // Back button click
    $(".back").click(function () {
        const currentStep = $(this).closest(".step").attr("id").replace("step", ""); // Get current step number
        const prevStep = parseInt(currentStep) - 1; // Calculate previous step
        showStep(prevStep); // Show the previous step
    });

    // Initial step setup
    showStep(1); // Show the first step by default
});
