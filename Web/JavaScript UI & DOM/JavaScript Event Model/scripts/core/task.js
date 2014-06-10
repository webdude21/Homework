function Task(params) {
    var TWO_WEEKS = 14;
    this.title = params.title || 'untitled';
    this.content = params.content || '';
    this.priority = params.priority || 'normal';
    this.taskDate = new Date();
    this.dueDate = params.dueDate || new Date() + TWO_WEEKS;
}
