import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CourseService } from '../../services/course';
import { Course } from '../../models/course.model';

@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [],
  templateUrl: './course-list.html',
  styleUrl: './course-list.scss'
})
export class CourseListComponent implements OnInit {
  courses: Course[] = [];

  constructor(
    private courseService: CourseService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.courseService.getCourses().subscribe({
      next: (data) => {
        this.courses = data; // Punem datele în cutie
        console.log('Datele au fost salvate în variabilă:', this.courses);

        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error('Eroare:', err);
      }
    });
  }
}