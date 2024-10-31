function navigateTo(sectionId) {
    const section = document.getElementById(sectionId);
    if (section) {
        section.scrollIntoView({ behavior: "smooth" });
        alert(`Navigerar till: ${section.querySelector("h2").innerText}`);
    }
}
