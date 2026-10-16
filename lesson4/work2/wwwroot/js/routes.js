
async function loadAllStudents() {
    ClearDisplay();
    const tbody = document.getElementById("bodyTable");
    const table = document.getElementById("studentsTable");
    table.style.display = "block";

    const res = await fetch("/students/all");
    const students = await res.json();

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

function ClearDisplay() {
    document.getElementById("studentsTable").style.display = "none";
    document.getElementById("groupTable").style.display = "none";
    
}
