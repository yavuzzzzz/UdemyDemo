import React from 'react';
import { useForm } from 'react-hook-form';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import alertify from 'alertifyjs';

function LoginForm() {
  const { register, handleSubmit, formState: { errors } } = useForm();

  const onSubmit = (data) => {
    alertify.success('Login başarılı!');
    console.log(data);
  };

  return (
    <Form onSubmit={handleSubmit(onSubmit)}>
      <FormGroup>
        <Label for="email">Email</Label>
        <Input
          type="email"
          id="email"
          {...register('email', { required: 'Email gerekli!', pattern: /^\S+@\S+$/i })}
        />
        {errors.email && <p className="text-danger">{errors.email.message}</p>}
      </FormGroup>

      <FormGroup>
        <Label for="password">Şifre</Label>
        <Input
          type="password"
          id="password"
          {...register('password', { required: 'Şifre gerekli!', minLength: 6 })}
        />
        {errors.password && <p className="text-danger">{errors.password.message}</p>}
      </FormGroup>

      <Button color="primary" type="submit">Giriş Yap</Button>
    </Form>
  );
}

export default LoginForm;
