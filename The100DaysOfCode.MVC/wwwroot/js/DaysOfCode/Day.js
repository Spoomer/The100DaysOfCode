document.querySelectorAll("input[goalId]")
.forEach(function (check) {
    check.addEventListener('change', function (event) {
        const dataObj = { id: check.getAttribute("goalid"), isChecked: check.checked }
        fetchPutFormData('/DaysOfCode/CheckGoal', dataObj)
    });
});

document.getElementById("btnAddGoal")
        .addEventListener('click',function () { 
            document.getElementById("liAddGoal").classList.remove("d-none");
            this.classList.add("d-none");
        });
document.getElementById("btnAddNote")
        .addEventListener('click',function () { 
            document.getElementById("liAddNote").classList.remove("d-none");
            this.classList.add("d-none");
        });
                