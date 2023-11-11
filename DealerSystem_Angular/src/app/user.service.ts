import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private readonly USER_KEY = 'loggedInUser';
  private loggedInUser: any;

  constructor() {
    const storedUser = localStorage.getItem(this.USER_KEY);
    this.loggedInUser = storedUser ? JSON.parse(storedUser) : null;
  }

  setLoggedInUser(user: any): void {
    this.loggedInUser = user;
    localStorage.setItem(this.USER_KEY, JSON.stringify(user));
  }

  getLoggedInUser(): any {
    return this.loggedInUser;
  }

  clearLoggedInUser(): void {
    this.loggedInUser = null;
    localStorage.removeItem(this.USER_KEY);
  }

  isLoggedIn(): boolean {
    return !!this.loggedInUser;
  }
}
