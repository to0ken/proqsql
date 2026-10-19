async function loadAllStudents() {
    ClearDisplay();
    
    const table = document.getElementById("studentsTable");
    table.style = "display:block";

    const res = await fetch("/students/all");
    students = await res.json();

    for (const s of students) {
        const tr = document.createElement('tr');
        tr.innerHTML =
            `<td>${s.id}</td>` +
            `<td>${s.firstName}</td>` +
            `<td>${s.lastName}</td>` +
            `<td>${s.age}</td>` +
            `<td>${s.groupId}</td>`;
        tbody.appendChild(tr);
    }
}

async function loadAllGroups() {
    ClearDisplay();
    const tbody = document.getElementById("groupBody");
    const table = document.getElementById("groupTable");
    table.style.display = "block";

    const res = await fetch("/group/all");
    const groups = await res.json();

    for (const g of groups) {
        const tr = document.createElement('tr');
        tr.innerHTML =
            `<td>${g.groupId}</td>` +
            `<td>${g.groupName}</td>`;
        tbody.appendChild(tr);
    }
}

async function CreateStudent() {
    const first_name = document.getElementById("first_name").value;
    const last_name = document.getElementById("last_name").value;      
    const age = parseInt(document.getElementById("age").value);
    const group_id = parseInt(document.getElementById("group_id").value);

    const res = await fetch("/student/", {
        method: "POST",
        headers: { "Content-Type": "application/json" },  
        body: JSON.stringify({
            FirstName: first_name,   
            LastName: last_name,
            Age: age,
            GroupId: group_id
        })
    });
}

function ClearDisplay() {
    document.getElementById("studentsTable").style.display = "none";
    document.getElementById("groupTable").style.display = "none";
}
