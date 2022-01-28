document.querySelectorAll("input[goalId]")
.forEach(function (check) {
    check.addEventListener('change', function (event) {
        const goalId = check.getAttribute("goalid");
        const dataObj = { id: goalId, isChecked: check.checked }
        fetchPutFormData('/DaysOfCode/CheckGoal', dataObj)
        if (check.checked)
        {
            document.getElementById("goal_"+goalId).classList.add("text-decoration-line-through");
        }
        else
        {
            document.getElementById("goal_"+goalId).classList.remove("text-decoration-line-through")
        }
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
                