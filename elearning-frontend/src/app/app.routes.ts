import { Routes } from '@angular/router';
import { CourseListComponent } from './components/course-list/course-list';

export const routes: Routes = [
    { path: '', redirectTo: 'courses', pathMatch: 'full' },
    { path: 'courses', component: CourseListComponent }
];