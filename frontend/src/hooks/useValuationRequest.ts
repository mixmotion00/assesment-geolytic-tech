import axios from "axios"
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import type { FormFields, PropertyTypeDto, ValuationRequestDto } from "../utils/type";

export const useValuationRequest = () => {

    const url = "http://localhost:5049/api";
    const queryClient = useQueryClient();

    const loadValuationRequestList = useQuery({
        queryKey: ['load-request'],
        queryFn: async () => {
            const res = await axios.get<ValuationRequestDto[]>(`${url}/valuation-requests`);
            return res.data; // return data instead object
        },
        staleTime: 60 * 1000, // 1 minute
        refetchOnMount: true,
        refetchOnWindowFocus: false,
    })

    const getPropertyTypes = async (): Promise<PropertyTypeDto[]> => {
        const response = await axios.get<PropertyTypeDto[]>(`${url}/property-types`);
        return response.data;
    };

        // check if success
    const submitRequest = useMutation({
        mutationFn: async(form:FormFields) =>{
            // fetch post here
            // return to pass results back to React Query
            return await axios.post(
                // 'http://localhost:5137/employee/leave-request', 
                `${url}/create-valuation`, 
                form)
        },
        // onSuccess is callback runs after mutatuin succeeds
        onSuccess: async()=>{
            // queryKey is how ReactQuery identify cache of query
            await queryClient.invalidateQueries({queryKey:['load-request']})
        }
    });

    return { loadValuationRequestList, getPropertyTypes, submitRequest }
}