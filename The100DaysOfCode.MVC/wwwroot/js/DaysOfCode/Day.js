//update marked Goal
let xrsftoken = document.getElementsByName("__RequestVerificationToken")[0].value
document.querySelectorAll("input[goalId]")
.forEach(function (check) {
    check.addEventListener('change', function () {
        const goalId = check.getAttribute("goalid");
        const dataObj = { id: goalId, isChecked: check.checked, __RequestVerificationToken: xrsftoken}
        fetchPutFormData('/DaysOfCode/CheckGoal', dataObj)
        if (check.checked)
        {
            document.getElementById("goal_"+goalId).classList.add("text-decoration-line-through");
            document.getElementById("btnGoalEdit_"+goalId).classList.add("d-none");
        }
        else
        {
            document.getElementById("goal_"+goalId).classList.remove("text-decoration-line-through")
            document.getElementById("btnGoalEdit_"+goalId).classList.remove("d-none");
        }
    });
});

// add Goal
document.getElementById("btnAddGoal")
        .addEventListener('click',function () { 
            document.getElementById("liAddGoal").classList.remove("d-none");
            this.classList.add("d-none");
        });

// add Note
document.getElementById("btnAddNote")
        .addEventListener('click',function () { 
            document.getElementById("liAddNote").classList.remove("d-none");
            this.classList.add("d-none");
        });

// edit Note
document.querySelectorAll("button[btnNoteEditId]")
.forEach(function(btnNoteEdit){
        btnNoteEdit.addEventListener('click', function() {
            const noteId = btnNoteEdit.getAttribute("btnNoteEditId");
            const textareaNote =document.getElementById("textareaNote_"+noteId);
            textareaNote.removeAttribute("readonly");
            btnNoteEdit.classList.add("d-none");
            const btnSaveNote = document.getElementById("btnNoteSave_"+noteId);
            btnSaveNote.classList.remove("d-none");
            btnSaveNote.addEventListener('click',function(){
                    saveNote(noteId,btnSaveNote,btnNoteEdit,textareaNote);
                });
        });
    })

// save edited Note
function saveNote(noteId, btnSaveNote,btnNoteEdit,textareaNote)  {
    fetchPutFormData('/DaysOfCode/UpdateNote',{ id: noteId, text: textareaNote.value, __RequestVerificationToken: xrsftoken});
    btnSaveNote.classList.add("d-none");
    btnNoteEdit.classList.remove("d-none");
    textareaNote.setAttribute("readonly","");
    btnSaveNote.removeEventListener('click',this);
}

// edit Goal
document.querySelectorAll("button[btnGoalEditId]")
.forEach(function(btnGoalEdit){
        btnGoalEdit.addEventListener('click', function() {
            const goalId = btnGoalEdit.getAttribute("btnGoalEditId");
            const inputGoal =document.getElementById("goal_"+goalId);
            inputGoal.removeAttribute("readonly");
            btnGoalEdit.classList.add("d-none");
            const btnSaveGoal = document.getElementById("btnGoalSave_"+goalId);
            btnSaveGoal.classList.remove("d-none");
            btnSaveGoal.addEventListener('click',function(){
                    saveGoal(goalId,btnSaveGoal,btnGoalEdit,inputGoal);
                });
        });
    })

// save edited Goal
function saveGoal(goalId, btnSaveGoal,btnGoalEdit,inputGoal)  {
    fetchPutFormData('/DaysOfCode/UpdateGoal',{ id: goalId, name: inputGoal.value, __RequestVerificationToken: xrsftoken});
    btnSaveGoal.classList.add("d-none");
    btnGoalEdit.classList.remove("d-none");
    inputGoal.setAttribute("readonly","");
    btnSaveGoal.removeEventListener('click',this);
}                