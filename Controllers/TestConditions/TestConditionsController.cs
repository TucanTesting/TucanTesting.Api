using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TucanTesting.Models;
using TucanTesting.Data;
using System.Linq;
using TucanTesting.Filters;

namespace TucanTesting.Controllers.TestConditions
{
    [Route("/api/test-conditions")]
    public class TestConditionsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITestConditionRepository _repository;

        public TestConditionsController(IMapper mapper, IUnitOfWork unitOfWork, ITestConditionRepository repository)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestCondition([FromBody] TestConditionResource resource)
        {
            var testCondition = _mapper.Map<TestConditionResource, TestCondition>(resource);
            _repository.Add(testCondition);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<TestCondition, TestConditionResource>(testCondition);

            return Ok(result);
        }

        [HttpGet]
        public async Task<List<TestConditionResource>> GetTestConditions()
        {
            var testConditions = await _repository.GetAll();
            return _mapper.Map<List<TestCondition>, List<TestConditionResource>>(testConditions);
        }

        [HttpPut("{id}")]
        [ValidateModelIdFilter("id", "testConditionResource")]
        public async Task<IActionResult> UpdateTestCondition(long id, [FromBody] TestConditionResource testConditionResource)
        {
            var testCondition = await _repository.Get(id);

            if (testCondition == null)
                return NotFound();

            var result = _mapper.Map<TestConditionResource, TestCondition>(testConditionResource, testCondition);
            await _unitOfWork.CompleteAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestCondition(long id)
        {
            var testCondition = await _repository.Get(id);

            if (testCondition == null)
                return NotFound();

            _repository.Remove(testCondition);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}