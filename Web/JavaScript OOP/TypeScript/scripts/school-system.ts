module schoolSystem {

    export class Person {
        firstName:string;
        lastName:string;
        age:number;

        constructor(firstName:string, lastName:string, age:number) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        toString() {
            return 'My name is: ' + this.firstName + ' ' +
                this.lastName + " and I'm " + this.age + ' years old'
        }
    }

    export class Student extends Person {
        grade:number;

        constructor(firstName:string, lastName:string, age:number, grade:number) {
            super(firstName, lastName, age);
            this.grade = grade;
        }

        toString() {
            return super.toString() + ', my grade is: ' + this.grade;
        }
    }

    export class Teacher extends Person {
        specialty:string;

        constructor(firstName:string, lastName:string, age:number, specialty:string) {
            super(firstName, lastName, age);
            this.specialty = specialty;
        }

        toString() {
            return super.toString() + ', specialty is: ' + this.specialty;
        }
    }

    export class SchoolClass {
        students:Student[];
        teacher:Teacher;

        constructor(teacher:Teacher, students?:Student[]) {
            this.teacher = teacher;
            if (students) {
                this.students = students;
            } else {
                this.students = [];
            }
        }

        addStudents(students:Student[]) {
            for (var i = 0; i < students.length; i++) {
                this.students.push(students[i]);
            }
        }

        toString() {
            return this.students.join(' - ');
        }
    }
}






