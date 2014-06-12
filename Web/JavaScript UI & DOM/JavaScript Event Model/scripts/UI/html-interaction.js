var TASK_ID_INFO_IN_HTML = {
    titleID: 'in-title',
    contentID: 'ta-content',
    priorityClassName: 'rb-priority',
    dueDateID: 'due-date',
    addButtonID: 'btn-add',
    ulToAddTasksToID: 'ul-task-list',
    lowPriorityID: 'rb-low',
    normalPriorityID: 'rb-normal',
    highPriorityID: 'rb-high'
};

var organizer = (new Organizer());

var addTaskToOrganizer = function addTaskToOrganizer() {
    var taskInfo = retrieveTaskInformation(TASK_ID_INFO_IN_HTML);
    var taskToAdd = new Task(taskInfo);
    organizer.add(taskToAdd);
    var taskAsListItem = generateTaskHTML(taskToAdd);
    taskAsListItem.id = 'task-item-' + organizer.tasks.indexOf(taskToAdd);
    taskAsListItem.className += 'task-item';
    document.getElementById(TASK_ID_INFO_IN_HTML.ulToAddTasksToID).appendChild(taskAsListItem);
};

var removeTaskFromOrganizer = function removeTaskFromOrganizer(itemToDelete) {
    organizer.remove(itemToDelete.itemReference);
    itemToDelete.parentNode.removeChild(itemToDelete);
};

var loadIntoEditor = function loadIntoEditor(itemToLoad) {
    document.getElementById(TASK_ID_INFO_IN_HTML.titleID).value = itemToLoad.title;
    document.getElementById(TASK_ID_INFO_IN_HTML.contentID).value = itemToLoad.content;
    document.getElementById(TASK_ID_INFO_IN_HTML.dueDateID).value = itemToLoad.dueDate;

    var priority;

    switch (TASK_ID_INFO_IN_HTML.priority) {
        case 'high':
            priority = TASK_ID_INFO_IN_HTML.highPriorityID;
            break;
        case 'low':
            priority = TASK_ID_INFO_IN_HTML.lowPriorityID;
            break;
        default:
            priority = TASK_ID_INFO_IN_HTML.normalPriorityID;
    }

    document.getElementById(priority).checked = "checked";
};

attachEvents(TASK_ID_INFO_IN_HTML);

function attachEvents(args) {
    document.getElementById(args.addButtonID).addEventListener('click', addTaskToOrganizer);
}

function retrieveTaskInformation(args) {
    var priorityGroup = document.getElementsByClassName(args.priorityClassName);
    var priority;
    var fallBackDueDate = new Date();
    fallBackDueDate.setDate(fallBackDueDate.getDate() + 14);
    var calendarDate = document.getElementById(args.dueDateID).value;
    calendarDate = calendarDate.split('-');

    var validDate = calendarDate[1] > 0 && calendarDate[1] < 13 && calendarDate[2] > 0 && calendarDate[2] < 32
        && calendarDate[0] > 1900 && calendarDate[0] < 3000;
    var date;

    if (validDate) {
        date = new Date(calendarDate[0], calendarDate[1] - 1, calendarDate[2], 0, 0, 0, 0)
    }else {
        date = fallBackDueDate;
    }

    for (var i = 0, len = priorityGroup.length; i < len; i++) {
        if (priorityGroup[i].checked) {
            priority = priorityGroup[i].value;
            break;
        }
    }

    return ({
        title: document.getElementById(args.titleID).value,
        content: document.getElementById(args.contentID).value,
        priority: priority,
        dueDate: date
    });
}

var renderTaskListHTML = function renderTaskListHTML(organizer) {
    var htmlFragment = document.createDocumentFragment();
    for (var i = 0; i < organizer.tasks.length; i++) {
        var currentListItem = generateTaskHTML(organizer.tasks[i]);
        currentListItem.id = 'task-item-' + i;
        currentListItem.className += 'task-item';
        htmlFragment.appendChild(currentListItem);
    }

    document.getElementById(TASK_ID_INFO_IN_HTML.ulToAddTasksToID).appendChild(htmlFragment);
};

function generateTaskHTML(task) {
    var currentTask = document.createElement('li');
    currentTask.itemReference = task;
    var title = document.createElement('p');
    title.className += ' task-item-title';
    title.textContent = task.title;
    var dueDate = document.createElement('span');
    dueDate.className += ' task-item-due-date';
    dueDate.textContent = 'Due: ' + task.dueDate.toDateString();
    var priority = document.createElement('span');
    priority.className += ' task-item-priority';
    var deleteButton = document.createElement('button');
    deleteButton.className += ' delete-btn';
    deleteButton.textContent = 'X';

    deleteButton.addEventListener('click', function (event) {
        removeTaskFromOrganizer(event.target.parentNode);
    });
    currentTask.addEventListener('click', function (event) {
        loadIntoEditor(event.target.itemReference);
    });

    switch (task.priority) {
        case 'high':
            priority.style.backgroundColor = 'red';
            break;
        case 'low':
            priority.style.backgroundColor = 'green';
            break;
        default:
            priority.style.backgroundColor = 'yellow';
    }

    currentTask.appendChild(title);
    currentTask.appendChild(priority);
    currentTask.appendChild(dueDate);
    currentTask.appendChild(deleteButton);

    return currentTask;
}