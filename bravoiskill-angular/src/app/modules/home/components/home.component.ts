import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { User } from '../../../shared/shared-models/user';
import { UserService } from '../../../shared/shared-services/user.service';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent implements OnInit {
    loading = false;
    users: User[];

    constructor(private userService: UserService) { }

    ngOnInit() {
        this.loading = true;
        this.userService.getAllUsers().pipe(first()).subscribe(users => {
            this.loading = false;
            this.users = users;
        });
    }
}
