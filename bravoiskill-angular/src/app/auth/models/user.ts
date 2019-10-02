export interface User {
  userId: number;
  email: string;
  password: string;
  firstName: string;
  lastName: string;
  dateOfBirth: Date;
  token?: string;
  skype: string;
}
