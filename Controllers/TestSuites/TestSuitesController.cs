using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToucanTesting.Models;
using ToucanTesting.Data;
using ToucanTesting.Utils;
using ToucanTesting.Filters;
using Microsoft.AspNetCore.Authorization;

namespace ToucanTesting.Controllers.TestSuites
{
    [Route("/test-suites")]
    public class TestSuitesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITestSuiteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public TestSuitesController(IMapper mapper, ITestSuiteRepository repository, IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTestSuites()
        {
            var testSuites = await _repository.GetSuites();

            return Ok(_mapper.Map<List<TestSuite>, List<TestSuiteResource>>(testSuites));
        }

        [HttpGet("{id}/export")]
        public async Task<IActionResult> ExportTestSuite(long id)
        {
            var testSuite = await _repository.GetSuite(id, true);
            if (testSuite == null)
            {
                return NotFound();
            }

            CsvGenerator csvGenerator = new CsvGenerator();
            return Ok(csvGenerator.GenerateFromSuite(testSuite));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestSuite(long id)
        {
            var testSuite = await _repository.GetSuite(id);

            if (testSuite == null)
            {
                return NotFound();
            }

            var suiteResource = _mapper.Map<TestSuite, TestSuiteResource>(testSuite);
            return Ok(suiteResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestSuite([FromBody] TestSuiteResource resource)
        {
            var testSuite = _mapper.Map<TestSuiteResource, TestSuite>(resource);
            _repository.Add(testSuite);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<TestSuite, TestSuiteResource>(testSuite);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ValidateModelIdFilter("id", "suiteResource")]
        public async Task<IActionResult> UpdateTestSuite(long id, [FromBody] TestSuiteResource suiteResource)
        {
            var testSuite = await _repository.GetSuite(id);

            if (testSuite == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<TestSuiteResource, TestSuite>(suiteResource, testSuite);
            await _unitOfWork.CompleteAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestSuite(long id)
        {
            var testSuite = await _repository.GetSuite(id);

            if (testSuite == null)
                return NotFound();

            _repository.Remove(testSuite);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}