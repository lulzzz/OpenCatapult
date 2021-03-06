import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProjectComponent } from './project/project.component';
import { ProjectDetailComponent } from './project-detail/project-detail.component';
import { ProjectInfoComponent } from './project-info/project-info.component';
import { ProjectNewComponent } from './project-new/project-new.component';
import { ProjectCloneComponent } from './project-clone/project-clone.component';
import { ProjectArchiveDetailComponent } from './project-archive-detail/project-archive-detail.component';
import { AuthorizePolicy } from '@app/core';
import { AuthGuard } from '@app/core/auth/auth.guard';
import { ProjectDashboardComponent } from './project-dashboard/project-dashboard.component';
import { ProjectErrorComponent } from './project-error/project-error.component';
import { ProjectResolverService } from './services/project-resolver.service';
import { ProjectDeletingComponent } from './project-deleting/project-deleting.component';

const routes: Routes = [
  {
    path: '',
    component: ProjectComponent,
    canActivateChild: [AuthGuard],
    children:
    [
      {
        path: '',
        component: ProjectDashboardComponent
      },
      {
        path: 'new',
        component: ProjectNewComponent,
        data: { authPolicy: AuthorizePolicy.UserRoleBasicAccess }
      },
      {
        path: ':projectId/clone',
        component: ProjectCloneComponent,
        data: { authPolicy: AuthorizePolicy.ProjectOwnerAccess },
        resolve: {
          project: ProjectResolverService
        }
      },
      {
        path: ':projectId/error',
        component: ProjectErrorComponent
      },
      {
        path: 'archive/:projectId',
        component: ProjectArchiveDetailComponent,
        data: { authPolicy: AuthorizePolicy.ProjectOwnerAccess },
        resolve: {
          project: ProjectResolverService
        }
      },
      {
        path: 'deleting/:projectId',
        component: ProjectDeletingComponent,
        data: { authPolicy: AuthorizePolicy.ProjectOwnerAccess },
        resolve: {
          project: ProjectResolverService
        },
        children: [
          {path: '', redirectTo: 'job-queue', pathMatch: 'full'},
          {
            path: 'job-queue',
            loadChildren: './job-queue/job-queue.module#JobQueueModule',
            data: { authPolicy: AuthorizePolicy.ProjectMaintainerAccess }
          }
        ]
      },
      {
        path: ':projectId',
        component: ProjectDetailComponent,
        canActivateChild: [AuthGuard],
        resolve: {
          project: ProjectResolverService
        },
        children: [
          {path: '', redirectTo: 'info', pathMatch: 'full'},
          {
            path: 'info',
            component: ProjectInfoComponent,
            data: { authPolicy: AuthorizePolicy.ProjectAccess }
          },
          {
            path: 'data-model',
            loadChildren: './data-model/data-model.module#DataModelModule',
            data: { authPolicy: AuthorizePolicy.ProjectAccess }
          },
          {
            path: 'job-definition',
            loadChildren: './job-definition/job-definition.module#JobDefinitionModule',
            data: { authPolicy: AuthorizePolicy.ProjectContributorAccess }
          },
          {
            path: 'job-queue',
            loadChildren: './job-queue/job-queue.module#JobQueueModule',
            data: { authPolicy: AuthorizePolicy.ProjectMaintainerAccess }
          },
          {
            path: 'member',
            loadChildren: './member/member.module#MemberModule',
            data: { authPolicy: AuthorizePolicy.ProjectAccess }
          }
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjectRoutingModule { }
