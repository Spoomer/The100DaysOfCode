document.querySelectorAll("input[goalId]")
.forEach(function (check) {
    check.addEventListener('change', function () {
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
function saveNote(noteId, btnSaveNote,btnNoteEdit,textareaNote)  {
    fetchPutFormData('/DaysOfCode/UpdateNote',{ id: noteId, text: textareaNote.value});
    btnSaveNote.classList.add("d-none");
    btnNoteEdit.classList.remove("d-none");
    textareaNote.setAttribute("readonly","");
    btnSaveNote.removeEventListener('click',this);
}             