import { Component, OnInit } from '@angular/core';
import { StringConstants } from './StringConstants';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ProfileModel } from './profile.modle';
import { ProfileDisplayModel } from './profile-display.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  constructor(private http: HttpClient) {}
  ngOnInit(): void {}
  criteriaList: string[] = [
    StringConstants.NAME,
    StringConstants.ID,
    StringConstants.SKILL,
  ];

  techSkillList: string[] = [
    StringConstants.ANGULAR,
    StringConstants.ASP,
    StringConstants.AZURE,
    StringConstants.DOCKER,
    StringConstants.ENTITY,
    StringConstants.GIT,
    StringConstants.HTML,
    StringConstants.JENKINS,
    StringConstants.REACT,
    StringConstants.RESTFUL,
  ];

  nonTechSkillList: string[] = [
    StringConstants.APTI,
    StringConstants.COMM,
    StringConstants.SPOKEN,
  ];

  skillCriteria: string = StringConstants.SKILL;
  selectedSkill: string = this.techSkillList[0];
  selectedCriteria: string = StringConstants.NAME;
  stringConstants = StringConstants;
  criteriaValue: string = '';
  isLoading: boolean = false;
  profileList: ProfileModel[] = [];
  profileDisplay: ProfileDisplayModel[] = [];

  selectCriteriaHandler = ($event: any) => {
    this.selectedCriteria = $event.target.value;
  };

  selectSkillHandler = ($event: any) => {
    this.selectedSkill = $event.target.value;
    this.criteriaValue = $event.target.value;
  };

  profileSearchHandler = () => {
    this.isLoading = true;
    this.http
      .get<ProfileModel[]>(
        'https://localhost:5001/skill-tracker/api/v1/admin/' +
          this.selectedCriteria +
          '/' +
          this.criteriaValue
      )
      .subscribe((res: ProfileModel[]) => {
        this.profileList = res;
        this.sortProfile();
      })
      .add(() => {
        this.isLoading = false;
      });
  };

  sortProfile = () => {
    this.profileDisplay = [];
    this.profileList.forEach((profile) => {
      let sortedTechSkills: {
        name: string;
        value: number;
      }[] = [];
      this.techSkillList.forEach((skill) => {
        if (profile.technicalskill?.[skill] !== undefined) {
          sortedTechSkills.push({
            name: skill,
            value: profile.technicalskill[skill],
          });
        }
      });
      let sortedNonTechSkills: {
        name: string;
        value: number;
      }[] = [];
      this.nonTechSkillList.forEach((skill) => {
        if (profile.nontechnicalskill?.[skill] !== undefined) {
          sortedNonTechSkills.push({
            name: skill,
            value: profile.nontechnicalskill[skill],
          });
        }
      });
      sortedTechSkills.sort((a, b) => {
        if (a.value > b.value) {
          return -1;
        }
        if (a.value < b.value) {
          return 1;
        }
        return 0;
      });
      sortedNonTechSkills.sort((a, b) => {
        if (a.value > b.value) {
          return -1;
        }
        if (a.value < b.value) {
          return 1;
        }
        return 0;
      });
      this.convertToDisplayModel(
        profile,
        sortedTechSkills,
        sortedNonTechSkills
      );
    });
  };

  convertToDisplayModel = (
    profile: ProfileModel,
    sortedTechSkills: any,
    sortedNonTechSkills: any
  ) => {
    this.profileDisplay.push({
      Name: profile.name,
      AssociateId: profile.associateid,
      Mobile: profile.mobile,
      Email: profile.email,
      TechnicalSkill: sortedTechSkills,
      NonTechnicalSkill: sortedNonTechSkills,
    });
  };
}
