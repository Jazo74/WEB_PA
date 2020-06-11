const serverURL = 'https://localhost:5001';

const eventNameEl = document.querySelector("#eventName");
const eventDescEl = document.querySelector("#eventDesc");
const eventAddress = document.querySelector("#eventAddress");
const eventTime = document.querySelector("#eventTime");
const startButton = document.querySelector("#start-button");
const inputEventId = document.querySelector("#event-id");
const taskTableBody = document.querySelector("#tbody");
const mapsEl = document.querySelector(".maps");
startButton.addEventListener("click", onReqEvent);

let eventData = [];
let tasks = [];
let maps = [];



function onReqEvent() {
    const xhr = new XMLHttpRequest();
    xhr.addEventListener('load', onEventReceived);
    xhr.open('GET', serverURL + `/api/Event/${inputEventId.value}`);
    xhr.withCredentials = true; // pass along cookies
    xhr.send();
}


function onEventReceived() {
    eventData = JSON.parse(this.responseText);
    eventNameEl.innerText = `Event name: ${eventData[0].name}`;
    eventDescEl.innerText = `Event description: ${eventData[0].description}`;
    eventAddress.innerText = `Event address: ${eventData[0].address}`;
    eventTime.innerText = `Event time: ${eventData[0].time}`;
    const xhr = new XMLHttpRequest();
    xhr.addEventListener('load', onTasksReceived);
    xhr.open('GET', serverURL + `/api/Task/${eventData[0].eventID}`);
    xhr.withCredentials = true; // pass along cookies
    xhr.send();
}

function onTasksReceived() {
    tasks = JSON.parse(this.responseText);
    reqMaps();
    while (taskTableBody.firstChild) {
        taskTableBody.removeChild(taskTableBody.firstChild)
    }
    for (i = 0; i < tasks.length; i++) {
        const trEl = document.createElement("tr");
        const tdEl1 = document.createElement("td");
        tdEl1.innerText = tasks[i].serialNumber;

        const tdEl2 = document.createElement("td");
        tdEl2.innerText = tasks[i].name;

        const tdEl3 = document.createElement("td");
        tdEl3.innerText = tasks[i].description;

        trEl.appendChild(tdEl1);
        trEl.appendChild(tdEl2);
        trEl.appendChild(tdEl3);
        taskTableBody.appendChild(trEl);
    }
}

function reqMaps() {
    const xhr = new XMLHttpRequest();
    xhr.addEventListener('load', onMapsReceived);
    xhr.open('GET', serverURL + `/api/Map/${eventData[0].eventID}`);
    xhr.withCredentials = true; // pass along cookies
    xhr.send();
}

function onMapsReceived() {
    maps = JSON.parse(this.responseText);
    console.log(maps);
    while (mapsEl.firstChild) {
        mapsEl.removeChild(mapsEl.firstChild)
    }
    for (j = 0; j < tasks.length; j++) {
        const trEl = document.createElement("img");
        trEl.src = maps[0].mapLink;
        mapsEl.appendChild(trEl);
    }
}