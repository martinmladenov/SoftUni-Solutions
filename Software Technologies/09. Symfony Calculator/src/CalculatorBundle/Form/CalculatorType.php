<?php

namespace CalculatorBundle\Form;

use Symfony\Component\Form\AbstractType;
use Symfony\Component\Form\Extension\Core\Type\NumberType;
use Symfony\Component\Form\Extension\Core\Type\TextType;
use Symfony\Component\Form\FormBuilderInterface;
use Symfony\Component\OptionsResolver\OptionsResolver;

class CalculatorType extends AbstractType
{
    public function buildForm(FormBuilderInterface $builder, array $options)
    {
        $builder
            ->add('leftOperand', NumberType::class)
            ->add('rightOperand', NumberType::class)
            ->add('operator', TextType::class);
    }

    public function configureOptions(OptionsResolver $resolver)
    {
        $resolver->setDefaults(array(
            'data_class' => 'CalculatorBundle\Entity\Calculator',
        ));
    }

    public function getName()
    {
        return 'soft_uni_blog_bundle_calculator_type';
    }
}
