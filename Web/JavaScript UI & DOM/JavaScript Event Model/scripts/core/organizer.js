function Organizer() {
    this.tasks = [];
}

Organizer.prototype.add = function add(task) {
    if (task instanceof Task) {
        this.tasks.push(task);
    } else {
        throw new TypeError('The organizer accepts only tasks!')
    }
};

Organizer.prototype.remove = function remove(task) {
    var index = this.tasks.indexOf(task);
    if (index !== -1) {
        this.tasks.splice(index, 1);
    }
};