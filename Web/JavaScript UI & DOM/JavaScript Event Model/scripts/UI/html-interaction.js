var TASK_ID_INFO_IN_HTML = {
    titleID: 'in-title',
    contentID: 'ta-content',
    priorityClassName: 'rb-priority',
    dueDateID: 'due-date',
    addButtonID: 'btn-add',
    ulToAddTasksToID: 'ul-task-list'
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

attachEvents(TASK_ID_INFO_IN_HTML);

function attachEvents(args) {
    document.getElementById(args.addButtonID).addEventListener('click', addTaskToOrganizer);
}

function retrieveTaskInformation(args) {
    var priorityGroup = document.getElementsByClassName(args.priorityClassName);
    var priority;

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
        dueDate: document.getElementById(args.dueDateID).value
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
        var itemToDelete = event.target.parentNode;
        organizer.remove(itemToDelete.itemReference);
        itemToDelete.parentNode.removeChild(itemToDelete);
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