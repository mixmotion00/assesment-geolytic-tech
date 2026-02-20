export interface ValuationRequestDto {
    id: number;
    propertyAddress: string;
    propertyTypeId: number;
    propertyTypeDto?: PropertyTypeDto; // nullable in C#
    requestedValue: number; // decimal -> number
    requestDate:string;
    status: string;
}

export interface PropertyTypeDto {
    id: number;
    name: string;
    code: string;
    isActive: boolean;
}
// {
//   "propertyAddress": "123 Main Street, Kuala Lumpur",
//   "propertyTypeId": 1,
//   "requestedValue": 350000.00,
//   "remarks": "This is a sample valuation request."
// }
// must match with backend CreateValuationRequestDto
export type FormFields = {
    propertyAddress: string;
    propertyTypeId: number;
    requestedValue: number;
    remarks: string;
}
