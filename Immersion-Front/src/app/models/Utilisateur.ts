import { Diplome } from "./Diplome";
import { HardSkill } from "./HardSkill";
import { SoftSkill } from "./SoftSkill";

export interface Utilisateur{
    id : number;
    email:string;
    lastName : string;
    firstName : string;
    isAdmin : boolean;
    hardSkills: HardSkill[];
    softSkills: SoftSkill[];
    diplomes : Diplome[];
    
}