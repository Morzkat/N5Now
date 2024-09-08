import { PermissionType } from "./permissionType";

export type Permission = {
    id?: number;
    name: string;
    lastName: string;
    permissionType: PermissionType;
    date?: Date;
}