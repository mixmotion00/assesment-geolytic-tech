import { Divider } from "@mui/material";
import { useValuationRequest } from "../hooks/useValuationRequest";
import { ValuationRequestItem } from "../components/ValuationRequestItem";

export function DisplayAll() {

    const { loadValuationRequestList } = useValuationRequest();

    return (
        <>
            <div className='table'>
                <span>Property Address</span>
                <span>Property Type</span>
                <span>Requested Value</span>
                <span>Status</span>
                <span>Request Date</span>
            </div>
            <Divider />
            {loadValuationRequestList.data?.map((v) => {
                return (<ValuationRequestItem key={v.id} valuationReq={v} />)
            })}
        </>
    );
}