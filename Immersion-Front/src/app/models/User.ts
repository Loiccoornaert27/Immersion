import { Diplome } from "./Diplome";
import { HardSkill } from "./HardSkill";
import { SoftSkill } from "./SoftSkill";

export interface User{
    id : number;
    email:string;
    firstName : string;
    lastName : string;
    isAdmin : boolean;
    hardSkills: HardSkill[] | null;
    softSkills: SoftSkill[] | null;
    diplomes : Diplome[] | null;
    
}