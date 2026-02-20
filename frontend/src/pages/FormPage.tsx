import { useEffect, useState } from 'react';
import type { FormFields, PropertyTypeDto } from '../utils/type';
import { useForm, type SubmitHandler } from "react-hook-form";
import { Button, Container } from '@mui/material';
import { useValuationRequest } from '../hooks/useValuationRequest';
import { toast } from 'react-toastify';
import type { AxiosError } from 'axios';

export function FormPage() {

    const [propertyTypes, setPropertyTypes] = useState<PropertyTypeDto[]>([]);

    const { register, handleSubmit, formState: { errors, isSubmitting } } = useForm<FormFields>();

    const onSubmit: SubmitHandler<FormFields> = async (data) => {
        // simulate wait 1 second
        await new Promise((resolve) => setTimeout(resolve, 1000));
        await submitRequest.mutateAsync(data);
        console.log(data); // just for log
    };

    const { getPropertyTypes, submitRequest } = useValuationRequest();

    const fetchTypes = async () => {
        const result = await getPropertyTypes(); // returns PropertyTypeDto[]
        setPropertyTypes(result); // store the full array
    };

    useEffect(() => {
        // disable warning, because this probably a bug
        // eslint-disable-next-line react-hooks/set-state-in-effect
        fetchTypes();
    }, [])

    useEffect(() => {
        if (submitRequest.isSuccess) {
            // what happend if success?
            toast.success("succesfully submit the request!");
            submitRequest.reset(); // prevent re-render
        }
        if (submitRequest.isError) {
            // what happen if error?
            toast.error(submitRequest.error.message); // returns base error

            const error = submitRequest.error as AxiosError<string>;
            toast.error(error.response?.data); // returns what cause it? eg: password must be etc

            submitRequest.reset(); // prevent re-render
        }
    }, [submitRequest, submitRequest.isSuccess, submitRequest.isError])

    return (

        <form onSubmit={handleSubmit(onSubmit)}>
            <Container sx={{
                display: 'flex', flexDirection: 'column',
                gap: 2, mt: 2, mb: 2, mr: 0, ml: 0,
                width: '700px'
            }}>
                {errors.propertyAddress && <div style={{ 'color': 'red' }}>{errors.propertyAddress.message}</div>}
                <input
                    {...register("propertyAddress", {
                        required: "Property Address is required",
                        minLength: {
                            value: 10,
                            message: "Property Address must be at least 10 characters",
                        },
                        maxLength: {
                            value: 200,
                            message: "Property Address cannot exceed 200 characters",
                        },
                    })}
                    className='input-style property'
                    placeholder='Property address'>
                </input>
                {errors.propertyTypeId && <div style={{ 'color': 'red' }}>{errors.propertyTypeId.message}</div>}
                <select
                    {...register("propertyTypeId", { required: "Property Type is required" })}
                    className="drop-down"
                    defaultValue=""
                >
                    <option value="" disabled>
                        Select Property Type
                    </option>
                    {propertyTypes.map((p) => (
                        <option key={p.id} value={p.id}>
                            {p.name}
                        </option>
                    ))}
                </select>

                <div className='custom-div'>
                    {errors.requestedValue && <div style={{ 'color': 'red' }}>{errors.requestedValue.message}</div>}
                    <span>Enter requested value</span>
                    <input
                        {...register("requestedValue", {
                            required: "Requested Value is required",   // required validation
                            valueAsNumber: true,                        // automatically convert value to number
                            validate: (value) =>
                                !isNaN(value) || "Requested Value must be a number", // numeric check
                            min: {
                                value: 1, // atleast 1
                                message: "Requested Value must not be zero",
                            },
                        })}
                        className="input-style"
                        type="number"
                        placeholder="Enter requested value"
                    />
                </div>
                {errors.remarks && <div style={{ 'color': 'red' }}>{errors.remarks.message}</div>}
                <textarea
                    {...register("remarks", {
                        maxLength: {
                            value: 500,
                            message: "Remarks cannot exceed 500 characters",
                        },
                    })}
                    placeholder='Remarks (max 500 characters)'
                />
                <Button disabled={isSubmitting} type='submit' variant="contained">{isSubmitting ? "Loading" : "Submit"}</Button>
            </Container>
        </form>
    )
}