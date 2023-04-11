const categoryFilterRadios = document.getElementsByName("categoryFilter")
const priceFilterRadios = document.getElementsByName("priceFilter");
const teacherFilterRadios = document.getElementsByName("teacherFilter");
const allFilters = document.getElementsByClassName("form-check-input")
const courses = document.getElementsByClassName("course");

for (let i = 0; i < allFilters.length; i++) {
    allFilters[i].addEventListener("click", filterCourses);
}

function filterCourses() {
    const selectedCategoryFilter = document.querySelector('input[name="categoryFilter"]:checked').value;
    const selectedPriceFilter = document.querySelector('input[name="priceFilter"]:checked').value;
    const selectedTeacherFilter = document.querySelector('input[name="teacherFilter"]:checked').value;

    for (let i = 0; i < courses.length; i++) {
        const course = courses[i];

        const category = course.getAttribute("course-category")
        const price = parseFloat(course.getAttribute("course-price"));
        const teacher = course.getAttribute("course-teacher");

        const matchesCategoryFilter = selectedCategoryFilter === "AllCategories" || selectedCategoryFilter === category;
        const matchesTeacherFilter = selectedTeacherFilter === "all" || selectedTeacherFilter === teacher;
        const matchesPriceFilter = selectedPriceFilter === "AllIn" ||
            (selectedPriceFilter === "FreeCourses" && price == 0) ||
            (selectedPriceFilter === "nonFreeCourses" && price > 0);

        if (matchesPriceFilter && matchesTeacherFilter && matchesCategoryFilter) {
            course.style.display = "";
        } else {
            course.style.display = "none";
        }
    }
}