function Task(params) {
    this.title = params.title || 'untitled';
    this.content = params.content || '';
    this.priority = params.priority || 'normal';
    this.dueDate = params.dueDate || fallBackDueDate;
}