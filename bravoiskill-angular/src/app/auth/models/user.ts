export interface User {
  userId: number;
  firstName: string;
  lastName: string;
  dateOfBirth: Date;
  email: string;
  password: string;
  token?: string;
  skype: string;
  photo: string;
  profileId: number;
  badgeId: number;
}
