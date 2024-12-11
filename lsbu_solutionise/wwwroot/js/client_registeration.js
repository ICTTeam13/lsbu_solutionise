$(document).ready(function () {
    // Function to show a specific step
    function showStep(step) {
        $(".step").hide(); // Hide all steps
        $(`#step${step}`).show(); // Show the specified step
    }

    // Next button click
    $(".next").click(function () {
        const currentStep = $(this).closest(".step").attr("id").replace("step", ""); // Get current step number
        const nextStep = parseInt(currentStep) + 1; // Calculate next step
        showStep(nextStep); // Show the next step
    });

    // Back button click
    $(".back").click(function () {
        const currentStep = $(this).closest(".step").attr("id").replace("step", ""); // Get current step number
        const prevStep = parseInt(currentStep) - 1; // Calculate previous step
        showStep(prevStep); // Show the previous step
    });
});