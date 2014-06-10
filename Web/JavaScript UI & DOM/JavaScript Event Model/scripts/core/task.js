function Task(params) {
    var fallBackDueDate = new Date();
    var numberOfDaysToAdd = 14;
    fallBackDueDate.setDate(fallBackDueDate.getDate() + numberOfDaysToAdd);
    this.title = params.title || 'untitled';
    this.content = params.content || '';
    this.priority = params.priority || 'normal';
    this.taskDate = new Date();
    this.dueDate = params.dueDate || fallBackDueDate;
}
