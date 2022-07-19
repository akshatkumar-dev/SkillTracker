export class ProfileDisplayModel {
  Name?: string;
  AssociateId?: string;
  Email?: string;
  Mobile?: string;
  TechnicalSkill?: {
    name: string;
    value: number;
  }[];
  NonTechnicalSkill?: {
    name: string;
    value: number;
  }[];
}
