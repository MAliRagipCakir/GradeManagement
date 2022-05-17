const apiUrl = "https://localhost:5001/";
const tableBody = $("#mainTableBody");

const frmNew = $("form#frmNewGrade");
const txtFirstName = $("input#txtFirstName");
const txtLastName = $("input#txtLastName");
const nbrMidTerm = $("input#nbrMidTerm");
const nbrFinal = $("input#nbrFinal");
const modalNew = $("#newModal");

const frmEdit = $("form#frmEditGrade");
const txtFirstNameEdit = $("input#txtFirstNameEdit");
const txtLastNameEdit = $("input#txtLastNameEdit");
const nbrMidTermEdit = $("input#nbrMidTermEdit");
const nbrFinalEdit = $("input#nbrFinalEdit");
const modalEdit = $("#editModal");

function addStudentGradeItem(item, prepend = false) {
    let tr = $("<tr/>").attr("data-id", item.id);
    tr[0].studentGradeItem = item;

    let td1 = $("<td/>").text(item.firstName);
    let td2 = $("<td/>").text(item.lastName);
    let td3 = $("<td/>").text(item.midTerm);
    let td4 = $("<td/>").text(item.final);
    let td5 = $("<td/>").addClass("d-flex flex-column flex-md-row justify-content-around");
    let buttonEdit = $("<button/>").addClass("btn btn-warning btn-sm mb-2 mb-md-0").text("Edit").click(EditClicked);
    let buttonDelete = $("<button/>").addClass("btn btn-danger btn-sm").text("Delete").click(deleteClicked);

    td5.append(buttonEdit).append(buttonDelete);

    tr.append(td1).append(td2).append(td3).append(td4).append(td5);
    if (prepend) tableBody.prepend(tr)
    else tableBody.append(tr);
}

function EditClicked(event) {
    modalEdit.modal('toggle');
    const tr = $(this).closest("tr");
    const studentGrade = tr[0].studentGradeItem;
    modalEdit[0].editingStudentGrade = studentGrade;
    txtFirstNameEdit.val(studentGrade.firstName);
    txtLastNameEdit.val(studentGrade.lastName);
    nbrMidTermEdit.val(studentGrade.midTerm);
    nbrFinalEdit.val(studentGrade.final);
}

function deleteClicked(event) {
    const tr = $(this).closest("tr");
    const id = tr.data("id");
    $.ajax({
        type: "DELETE",
        url: apiUrl + "api/studentGrades/" + id,
        success: function (data) {
            tr.remove();
        }
    });
}

function getStudentGrades() {
    tableBody.html("");
    $.ajax({
        type: "GET",
        url: apiUrl + "api/studentGrades",
        success: function (data) {
            for (const item of data) {
                addStudentGradeItem(item);
            }
        }
    });
}

frmNew.submit(function (event) {
    event.preventDefault();
    const newStudentGrade = { firstName: txtFirstName.val(), lastName: txtLastName.val(), midTerm: nbrMidTerm.val(), final: nbrFinal.val() };

    $.ajax({
        contentType: "application/json",
        type: "POST",
        url: apiUrl + "api/studentGrades",
        data: JSON.stringify(newStudentGrade),
        success: function (data) {
            addStudentGradeItem(data, true);
            txtFirstName.val("");
            txtLastName.val("");
            nbrMidTerm.val(0);
            nbrFinal.val(0);
            modalNew.modal('toggle');
        }
    }
    );
})

frmEdit.submit(function (event) {
    event.preventDefault();
    const id = modalEdit[0].editingStudentGrade.id;
    const studentGrade = { id: id, firstName: txtFirstNameEdit.val(), lastName: txtLastNameEdit.val(), midTerm: nbrMidTermEdit.val(), final: nbrFinalEdit.val() };

    $.ajax({
        type: "PUT",
        url: apiUrl + "api/studentGrades/" + studentGrade.id,
        data: JSON.stringify(studentGrade),
        contentType: "application/json",
        success: function (data) {
            getStudentGrades();
            txtFirstNameEdit.val("");
            txtLastNameEdit.val("");
            nbrMidTermEdit.val(0);
            nbrFinalEdit.val(0);
            modalEdit.modal('toggle');
        }
    });
})

getStudentGrades();