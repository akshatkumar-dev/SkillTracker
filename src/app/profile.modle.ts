export class ProfileModel {
  name?: string;
  associateid?: string;
  mobile?: string;
  email?: string;
  technicalskill?: {
    [htmlcssjavascript: string]: number;
    angular: number;
    react: number;
    aspdotnetcore: number;
    restful: number;
    entityframework: number;
    git: number;
    docker: number;
    jenkins: number;
    azure: number;
  };
  nontechnicalskill?: {
    [spoken: string]: number;
    communication: number;
    aptitude: number;
  };
}
