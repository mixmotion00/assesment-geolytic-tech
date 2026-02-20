import { formatCurrency } from "../utils/currencyhelper";
import { formatDate } from "../utils/datehelper";
import type { ValuationRequestDto } from "../utils/type";

type Prop = {
    valuationReq: ValuationRequestDto
}

export function ValuationRequestItem(prop: Prop) {

    const { valuationReq } = prop;

    return (
        <>
            <div className='table'>
                <span>{valuationReq.propertyAddress}</span>
                <span>{valuationReq.propertyTypeDto?.name}</span>
                <span>{formatCurrency(valuationReq.requestedValue)}</span>
                <span>{valuationReq.status}</span>
                <span>{formatDate(valuationReq.requestDate)}</span>
            </div>
        </>);
}